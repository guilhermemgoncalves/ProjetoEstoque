import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./pages/pages.module').then((m) => m.PagesModule),
  },
  { path: 'costumers', loadChildren: () => import('./pages/costumers/costumers.module').then(m => m.CostumersModule) },
  { path: 'dashboards', loadChildren: () => import('./pages/dashboards/dashboards.module').then(m => m.DashboardsModule) },
  { path: 'costumers-details', loadChildren: () => import('./pages/costumers-details/costumers-details.module').then(m => m.CostumersDetailsModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
