import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CostumersDetailsComponent } from './costumers-details.component';

const routes: Routes = [{ path: '', component: CostumersDetailsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CostumersDetailsRoutingModule { }
