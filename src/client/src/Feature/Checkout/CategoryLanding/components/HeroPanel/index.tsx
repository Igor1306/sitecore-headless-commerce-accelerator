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

import * as JSS from 'Foundation/ReactJss';

import { HeroPanelProps, HeroPanelState } from './models';

import './styles.scss';

export class HeroPanel extends JSS.SafePureComponent<HeroPanelProps, HeroPanelState> {
  public safeRender() {
    return (
        <figure className="category-promo-hero">
            <a href="#">
              <img src="https://placeholdit.imgix.net/~text?txtsize=20&txt=placeholder&w=1280&h=550" alt="Image Alt Text"/>
              <figcaption>
                <h2 className="category-promo-hero-text">
                  <span className="text-style1" />
                </h2>
              </figcaption>
            </a>
        </figure>
    );
  }
}
