import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorComponent } from './error/test-error/test-error.component';
import { NotFoundComponent } from './error/not-found/not-found.component';
import { ServerErrorComponent } from './error/server-error/server-error.component';

export const routes: Routes = [
    {path:'',component:HomeComponent},
    {
        path:'',
        runGuardsAndResolvers:'always',
        canActivate:[authGuard],
        children:[
            {path:'members',component:MemberListComponent},
            {path:'members/:id',component:MemberDetailsComponent},
            {path:'lists',component:ListsComponent},
            {path:'messages',component:MessagesComponent},
        ]
    },
    {path:'errors', component:TestErrorComponent},
    {path:'not-found', component:NotFoundComponent},
    {path:'server-error', component:ServerErrorComponent},
    {path:'**',component:HomeComponent,pathMatch:'full'}

];


