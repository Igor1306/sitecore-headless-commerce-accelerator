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

import * as React from 'react';
import * as JSS from '../../../../Foundation/ReactJss';
import { NavigationLink } from '../../../../Foundation/UI/common/components/Buttons/NavigationLink';
import { NavigationProps } from './models';

export class NavigationLinks extends JSS.SafePureComponent<NavigationProps, {}> {
  protected safeRender() {
    return (
      <ul>
        {this.props.links.map((link, index, firstLinkClassname) => {
          return (
            <li key={link.title}>
              {link.url ? (
                <NavigationLink className={this.props.className} to={link.url}>
                  {link.title}
                </NavigationLink>
              ) : (
                <span className="submenu_title">{link.title}</span>
              )}
            </li>
          );
        })}
      </ul>
    );
  }
}
