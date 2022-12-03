import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardsRoutingModule } from './dashboards-routing.module';
import { DashboardsComponent } from './dashboards.component';
import { HomeRoutingModule } from '../home/home-routing.module';


@NgModule({
  declarations: [
    DashboardsComponent
  ],
  imports: [
    CommonModule,
    DashboardsRoutingModule,
    HomeRoutingModule
  ],
  exports: [
    DashboardsComponent
  ]
})
export class DashboardsModule { }
