

import { BaseLayoutComponent } from './../components/base-layout/base-layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
  {
    path: '',
    component: BaseLayoutComponent,
    loadChildren: () =>
      import('../pages/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'tools',
    component: BaseLayoutComponent,
    loadChildren: () =>
      import('../pages/tools/tools.module').then((m) => m.ToolsModule),
  }
  ,
  {
    path: 'costumers',
    component: BaseLayoutComponent,
    loadChildren: () =>
      import('../pages/costumers/costumers.module').then((m) => m.CostumersModule),
  }
  ,
  {
    path: 'dashboards',
    component: BaseLayoutComponent,
    loadChildren: () =>
      import('../pages/dashboards/dashboards.module').then((m) => m.DashboardsModule),
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
