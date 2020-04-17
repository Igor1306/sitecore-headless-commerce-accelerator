﻿//    Copyright 2020 EPAM Systems, Inc.
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

namespace HCA.Foundation.Commerce.Mappers.Users
{
    using Account.Infrastructure.Pipelines.Login;

    using Base.Mappers;

    using DependencyInjection;

    using Models.Entities.Users;

    using Profiles;

    [Service(typeof(IUserMapper), Lifetime = Lifetime.Transient)]
    public class UserMapper : ProfileMapper<UserProfile>, IUserMapper
    {
        public void MapToLoginPipelineArgs(User user, LoginPipelineArgs args)
        {
            this.InnerMapper.Map(user, args);
        }
    }
}