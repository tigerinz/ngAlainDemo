import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';
import { CmsRoutingModule } from './cms-routing.module';
import { CmsCmslistComponent } from './cmslist/cmslist.component';
import { CmsModulelistComponent } from './modulelist/modulelist.component';

const COMPONENTS = [
  CmsCmslistComponent,
  CmsModulelistComponent];
const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [
    SharedModule,
    CmsRoutingModule
  ],
  declarations: [
    ...COMPONENTS,
    ...COMPONENTS_NOROUNT
  ],
  entryComponents: COMPONENTS_NOROUNT
})
export class CmsModule { }
