import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CostumersDetailsRoutingModule } from './costumers-details-routing.module';
import { CostumersDetailsComponent } from './costumers-details.component';


@NgModule({
  declarations: [
    CostumersDetailsComponent
  ],
  imports: [
    CommonModule,
    CostumersDetailsRoutingModule
  ]
})
export class CostumersDetailsModule { }
