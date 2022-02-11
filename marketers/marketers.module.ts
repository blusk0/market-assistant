import { RouterModule } from '@angular/router';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarketersComponent } from './marketers.component';
import { MarketerComponent } from './marketer/marketer.component';

@NgModule({
  declarations: [MarketersComponent, MarketerComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: ':id',
        component: MarketerComponent,
      },
      {
        path: '',
        component: MarketersComponent,
      },
    ]),
  ],
})
export class MarketersModule {}
