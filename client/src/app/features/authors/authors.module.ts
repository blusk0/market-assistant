import { SharedModule } from './../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthorsComponent } from './authors.component';
import { AuthorComponent } from './author/author.component';

@NgModule({
  declarations: [AuthorsComponent, AuthorComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: ':id',
        component: AuthorComponent,
      },
      {
        path: '',
        component: AuthorsComponent,
      },
    ]),
    SharedModule,
  ],
})
export class AuthorsModule {}
