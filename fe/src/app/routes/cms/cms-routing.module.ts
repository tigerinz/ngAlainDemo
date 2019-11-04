import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CmsCmslistComponent } from './cmslist/cmslist.component';
import { CmsModulelistComponent } from './modulelist/modulelist.component';

const routes: Routes = [

  { path: 'cmslist', component: CmsCmslistComponent },
  { path: 'modulelist', component: CmsModulelistComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CmsRoutingModule { }
