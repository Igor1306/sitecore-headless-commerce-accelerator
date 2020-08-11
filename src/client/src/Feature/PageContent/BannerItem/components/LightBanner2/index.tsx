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

import { Image, Text } from '@sitecore-jss/sitecore-jss-react';

import * as JSS from 'Foundation/ReactJss';

import { BannerProps, BannerState } from '../models';

import './styles.scss';

class LightBannerComponent extends JSS.SafePureComponent<BannerProps, BannerState> {
  public safeRender() {
    const { image, buttonText, link } = this.props.fields;
    return (
      <figure className="light-banner">
        <JSS.Link field={link}>
          <Image media={image} />
          <figcaption>
            <Text field={buttonText} tag="button" className="btn-light-banner" />
          </figcaption>
        </JSS.Link>
      </figure>
    );
  }
}

export const LightBanner2 = JSS.renderingWithContextAndDatasource(LightBannerComponent);
