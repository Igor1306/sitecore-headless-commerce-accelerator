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

import * as Base from 'Foundation/Base';
import * as Commerce from 'Foundation/Commerce';

export interface CreateAccountResponse extends Base.OkJsonResultModel<Commerce.User> {}

export interface EmailValidationResponse extends Base.OkJsonResultModel<Commerce.ValidateEmail> {}

export interface ChangePasswordResponse extends Base.OkJsonResultModel<Base.VoidResult> {}

export interface UpdateAccountResponse extends Base.OkJsonResultModel<Base.VoidResult> {}

export interface AddressResponse extends Base.OkJsonResultModel<Commerce.Address[]> {}