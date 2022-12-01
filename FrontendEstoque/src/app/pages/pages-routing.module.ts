import { ToolsModule } from './tools/tools.module';

import { BaseLayoutComponent } from './../components/base-layout/base-layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ToolsComponent } from './tools/tools.component';

const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    loadChildren: () =>
      import('../pages/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'tools',
    component: ToolsComponent,
    loadChildren: () =>
      import('../pages/tools/tools.module').then((m) => m.ToolsModule),
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
