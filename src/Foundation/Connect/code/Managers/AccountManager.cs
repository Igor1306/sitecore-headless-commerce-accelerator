//    Copyright 2020 EPAM Systems, Inc.
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

namespace Wooli.Foundation.Connect.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using Base.Models.Logging;
    using Base.Services.Logging;

    using DependencyInjection;

    using Providers.Contracts;

    using Sitecore.Commerce.Entities;
    using Sitecore.Commerce.Entities.Customers;
    using Sitecore.Commerce.Services.Customers;
    using Sitecore.Diagnostics;

    using Log = Sitecore.Diagnostics.Log;

    [Service(typeof(IAccountManager))]
    public class AccountManager : IAccountManager
    {
        private readonly ICartManager cartManager;

        private readonly CustomerServiceProvider customerServiceProvider;

        private readonly ILogService<CommonLog> logService;

        public AccountManager(
            IConnectServiceProvider connectServiceProvider,
            ICartManager cartManager,
            ILogService<CommonLog> logService)
        {
            Assert.ArgumentNotNull(connectServiceProvider, nameof(connectServiceProvider));
            Assert.ArgumentNotNull(cartManager, nameof(cartManager));

            this.customerServiceProvider = connectServiceProvider.GetCustomerServiceProvider();
            this.cartManager = cartManager;
            this.logService = logService;
        }

        public ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>> AddCustomerParties(
            CommerceCustomer customer,
            IEnumerable<CustomerParty> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var addCustomerPartiesRequest = new AddCustomerPartiesRequest(customer, parties.ToList());

            var addCustomerPartiesResult = this.customerServiceProvider.AddCustomerParties(addCustomerPartiesRequest);

            return new ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>>(addCustomerPartiesResult, null);
        }

        public ManagerResponse<AddPartiesResult, IEnumerable<Party>> AddParties(
            CommerceCustomer customer,
            IEnumerable<Party> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var addPartiesRequest = new AddPartiesRequest(customer, parties.ToList());

            var addPartiesResult = this.customerServiceProvider.AddParties(addPartiesRequest);

            return new ManagerResponse<AddPartiesResult, IEnumerable<Party>>(addPartiesResult, addPartiesRequest.Parties);
        }

        public ManagerResponse<CreateCustomerResult, CommerceCustomer> CreateCustomer(CommerceCustomer commerceCustomer)
        {
            Assert.ArgumentNotNull(commerceCustomer, nameof(commerceCustomer));

            var createCustomerRequest = new CreateCustomerRequest(commerceCustomer);

            var createCustomerResult = this.customerServiceProvider.CreateCustomer(createCustomerRequest);

            if (!createCustomerResult.Success)
            {
                Log.Warn("Create customer failed", this.GetType());
            }

            return new ManagerResponse<CreateCustomerResult, CommerceCustomer>(
                createCustomerResult,
                createCustomerResult.CommerceCustomer);
        }

        public ManagerResponse<CreateUserResult, CommerceUser> CreateUser(
            string userName,
            string email,
            string password,
            string shopName)
        {
            Assert.ArgumentNotNullOrEmpty(userName, nameof(userName));
            Assert.ArgumentNotNullOrEmpty(email, nameof(email));
            Assert.ArgumentNotNullOrEmpty(password, nameof(password));
            Assert.ArgumentNotNullOrEmpty(shopName, nameof(shopName));

            // Commerce needs domain name to be presented in the user name
            var fullUserName = $"{Constants.CommerceUsersDomainName}\\{userName}";

            var createUserRequest = new CreateUserRequest(fullUserName, password, email, shopName);

            var createUserResult = this.customerServiceProvider.CreateUser(createUserRequest);

            if (!createUserResult.Success || (createUserResult.CommerceUser == null))
            {
                Log.Warn("User creation failed", this.GetType());
            }

            return new ManagerResponse<CreateUserResult, CommerceUser>(createUserResult, createUserResult.CommerceUser);
        }

        public ManagerResponse<DisableUserResult, CommerceUser> DisableUser(CommerceUser commerceUser)
        {
            Assert.ArgumentNotNull(commerceUser, nameof(commerceUser));

            var disableUserRequest = new DisableUserRequest(commerceUser);

            var disableUserResult = this.customerServiceProvider.DisableUser(disableUserRequest);

            if (!disableUserResult.Success)
            {
                Log.Warn("Disable user failed", this.GetType());
            }

            return new ManagerResponse<DisableUserResult, CommerceUser>(disableUserResult, disableUserResult.CommerceUser);
        }

        public ManagerResponse<EnableUserResult, CommerceUser> EnableUser(CommerceUser commerceUser)
        {
            Assert.ArgumentNotNull(commerceUser, nameof(commerceUser));

            var enableUserRequest = new EnableUserRequest(commerceUser);

            var enableUserResult = this.customerServiceProvider.EnableUser(enableUserRequest);

            if (!enableUserResult.Success)
            {
                Log.Warn("Enable user failed", this.GetType());
            }

            return new ManagerResponse<EnableUserResult, CommerceUser>(enableUserResult, enableUserResult.CommerceUser);
        }

        public ManagerResponse<GetPartiesResult, IEnumerable<Party>> GetCurrentCustomerParties(string shopName, string contactId)
        {
            var getPartiesResult = new GetPartiesResult();

            var user = this.GetUser(contactId);
            if (!user.ServiceProviderResult.Success || (user.Result == null))
            {
                return new ManagerResponse<GetPartiesResult, IEnumerable<Party>>(getPartiesResult, null);
            }

            var customer = new CommerceCustomer
            {
                ExternalId = user.Result.ExternalId
            };
            return this.GetParties(customer);
        }

        public ManagerResponse<GetCustomerResult, CommerceCustomer> GetCustomer(string externalId)
        {
            Assert.ArgumentNotNullOrEmpty(externalId, nameof(externalId));

            var getCustomerRequest = new GetCustomerRequest(externalId);
            var getCustomerResult = this.customerServiceProvider.GetCustomer(getCustomerRequest);

            return new ManagerResponse<GetCustomerResult, CommerceCustomer>(
                getCustomerResult,
                getCustomerResult.CommerceCustomer);
        }

        public ManagerResponse<GetPartiesResult, IEnumerable<Party>> GetParties(CommerceCustomer customer)
        {
            var request = new GetPartiesRequest(customer);
            var parties = this.customerServiceProvider.GetParties(request);
            IEnumerable<Party> result = !parties.Success || (parties.Parties == null) ? new List<Party>() : parties.Parties;

            return new ManagerResponse<GetPartiesResult, IEnumerable<Party>>(parties, result);
        }

        public ManagerResponse<GetUserResult, CommerceUser> GetUser(string userName)
        {
            Assert.ArgumentNotNullOrEmpty(userName, nameof(userName));

            var user = this.customerServiceProvider.GetUser(new GetUserRequest(userName));
            if (!user.Success || (user.CommerceUser == null))
            {
                Log.Warn("User Not Found Error", this.GetType());
            }

            var serviceProviderResult = user;

            return new ManagerResponse<GetUserResult, CommerceUser>(serviceProviderResult, serviceProviderResult.CommerceUser);
        }

        public ManagerResponse<GetUsersResult, CommerceUser> GetUserByEmail(string email)
        {
            Assert.ArgumentNotNullOrEmpty(email, nameof(email));

            var users = this.customerServiceProvider.GetUsers(
                new GetUsersRequest(
                    new UserSearchCriteria
                    {
                        Email = email
                    }));
            if (!users.Success || (users.CommerceUsers == null) || (users.CommerceUsers.Count == 0))
            {
                this.logService.Warn("User Not Found Error");
            }

            var serviceProviderResult = users;

            return new ManagerResponse<GetUsersResult, CommerceUser>(
                serviceProviderResult,
                serviceProviderResult.CommerceUsers.FirstOrDefault());
        }

        public ManagerResponse<GetUsersResult, IList<CommerceUser>> GetUsers(UserSearchCriteria userSearchCriteria)
        {
            var getUsersRequest = new GetUsersRequest(userSearchCriteria);
            var serviceProviderResult = this.customerServiceProvider.GetUsers(getUsersRequest);

            if (!serviceProviderResult.Success)
            {
                return new ManagerResponse<GetUsersResult, IList<CommerceUser>>(serviceProviderResult, new List<CommerceUser>());
            }

            return new ManagerResponse<GetUsersResult, IList<CommerceUser>>(
                serviceProviderResult,
                serviceProviderResult.CommerceUsers);
        }

        public ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>> RemoveCustomerParties(
            CommerceCustomer customer,
            IEnumerable<CustomerParty> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var removeCustomerPartiesRequest = new RemoveCustomerPartiesRequest(customer, parties.ToList());

            var removeCustomerPartiesResult = this.customerServiceProvider.RemoveCustomerParties(removeCustomerPartiesRequest);

            return new ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>>(removeCustomerPartiesResult, null);
        }

        public ManagerResponse<CustomerResult, IEnumerable<Party>> RemoveParties(
            CommerceCustomer customer,
            IEnumerable<Party> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var removePartiesRequest = new RemovePartiesRequest(customer, parties.ToList());

            var removePartiesResult = this.customerServiceProvider.RemoveParties(removePartiesRequest);

            return new ManagerResponse<CustomerResult, IEnumerable<Party>>(removePartiesResult, null);
        }

        public ManagerResponse<UpdateCustomerResult, CommerceCustomer> UpdateCustomer(CommerceCustomer commerceCustomer)
        {
            Assert.ArgumentNotNull(commerceCustomer, nameof(commerceCustomer));

            var updateCustomerRequest = new UpdateCustomerRequest(commerceCustomer);

            var updateCustomerResult = this.customerServiceProvider.UpdateCustomer(updateCustomerRequest);

            if (!updateCustomerResult.Success)
            {
                Log.Warn("Update customer failed", this.GetType());
            }

            return new ManagerResponse<UpdateCustomerResult, CommerceCustomer>(
                updateCustomerResult,
                updateCustomerResult.CommerceCustomer);
        }

        public ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>> UpdateCustomerParties(
            CommerceCustomer customer,
            IEnumerable<CustomerParty> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var updateCustomerPartiesRequest = new UpdateCustomerPartiesRequest(customer, parties.ToList());

            var updateCustomerPartiesResult = this.customerServiceProvider.UpdateCustomerParties(updateCustomerPartiesRequest);

            return new ManagerResponse<CustomerPartiesResult, IEnumerable<CustomerParty>>(updateCustomerPartiesResult, null);
        }

        public ManagerResponse<CustomerResult, IEnumerable<Party>> UpdateParties(
            CommerceCustomer customer,
            IEnumerable<Party> parties)
        {
            Assert.ArgumentNotNull(customer, nameof(customer));
            Assert.ArgumentNotNull(parties, nameof(parties));

            var updatePartiesRequest = new UpdatePartiesRequest(customer, parties.ToList());

            var updatePartiesResult = this.customerServiceProvider.UpdateParties(updatePartiesRequest);

            return new ManagerResponse<CustomerResult, IEnumerable<Party>>(updatePartiesResult, null);
        }

        public ManagerResponse<UpdateUserResult, CommerceUser> UpdateUser(CommerceUser updatedCommerceUser)
        {
            Assert.ArgumentNotNull(updatedCommerceUser, nameof(updatedCommerceUser));

            var updateUserRequest = new UpdateUserRequest(updatedCommerceUser);

            var updateUserResult = this.customerServiceProvider.UpdateUser(updateUserRequest);

            if (!updateUserResult.Success)
            {
                Log.Warn("User update failed", this.GetType());
            }

            return new ManagerResponse<UpdateUserResult, CommerceUser>(updateUserResult, updateUserResult.CommerceUser);
        }
    }
}