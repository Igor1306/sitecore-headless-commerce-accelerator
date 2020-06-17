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

import * as JSS from 'Foundation/ReactJss';
import * as React from 'react';

import { NavigationLink } from 'Foundation/UI';

import { UserNavigationProps, UserNavigationState } from './models';
import { SignIn } from './SignIn';
import { SignOut } from './SignOut';
import './styles.scss';

export class UserNavigationComponent extends JSS.SafePureComponent<UserNavigationProps, UserNavigationState> {
  private popupWrapperRef: React.RefObject<HTMLLIElement>;

  constructor(props: UserNavigationProps) {
    super(props);

    this.state = {
      userFormVisible: false,
    };

    this.popupWrapperRef = React.createRef<HTMLLIElement>();
    document.addEventListener('click', this.handleOutsidePopupClick.bind(this), false);
  }

  protected safeRender() {
    const { cartQuantity, commerceUser } = this.props;
    const { userFormVisible } = this.state;

    return (
      <nav className="user-navigation">
        <ul>
          <li>
            <NavigationLink to="/wishlist">
              <i className="fa fa-list-ul" />
              <span>Wishlist</span>
            </NavigationLink>
          </li>
          <li>
            <NavigationLink to="/cart">
              <i className="fa fa-shopping-cart">
                {cartQuantity > 0 && <span className="quantity">{cartQuantity}</span>}
              </i>
              <span>Shopping Cart</span>
            </NavigationLink>
          </li>
          <li ref={this.popupWrapperRef}>
            <a onClick={this.togglePopup}>
              <i className="fa fa-user" />
              <span>My Account</span>
            </a>
            {userFormVisible && (
              <div className="login-form">
                {!!commerceUser && commerceUser.customerId ? (
                  <SignOut onLoaded={this.togglePopup} />
                ) : (
                  <SignIn onLoaded={this.togglePopup} />
                )}
              </div>
            )}
          </li>
        </ul>
      </nav>
    );
  }

  private handleOutsidePopupClick(e: MouseEvent) {
    if (
      this.popupWrapperRef.current &&
      !this.popupWrapperRef.current.contains(e.target as Node) &&
      this.state.userFormVisible
    ) {
      this.togglePopup();
    }
  }

  private togglePopup = () => this.setState({ userFormVisible: !this.state.userFormVisible });
}