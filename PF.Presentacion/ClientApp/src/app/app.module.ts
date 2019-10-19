import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Third party imports
import { NgxLoadingModule } from "ngx-loading";
import { FamiliesComponent } from './families/families.component';
import { FamiliesFormComponent } from './families/families-form/families-form.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        FamiliesComponent,
        FamiliesFormComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', component: NavMenuComponent, pathMatch: 'full' },
            { path: 'families', component: FamiliesComponent },
            { path: 'families-add', component: FamiliesFormComponent },
            { path: 'families-edit/:id', component: FamiliesFormComponent },
        ]),
        BrowserAnimationsModule,
        NgxLoadingModule.forRoot({})
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
