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
import { DatePipe } from '@angular/common'

//Third party imports
import { NgxLoadingModule } from "ngx-loading";
import { FamiliesComponent } from './families/families.component';
import { FamiliesFormComponent } from './families/families-form/families-form.component';
import { CategoriesComponent } from './categories/categories.component';
import { CategoriesFormComponent } from './categories/categories-form/categories-form.component';
import { MaterialsComponent } from './materials/materials.component';
import { MaterialsFormComponent } from './materials/materials-form/materials-form.component';
import { ItemsComponent } from './items/items.component';
import { ItemsFormComponent } from './items/items-form/items-form.component';
import { CalculationComponent } from './calculation/calculation.component';
import { ConstructionComponent } from './construction/construction.component';
import { ConstructionFormComponent } from './construction/construction-form/construction-form.component';
import { ConstructionDetailFormComponent } from './construction/construction-form/construction-form.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        FamiliesComponent,
        FamiliesFormComponent,
        CategoriesComponent,
        CategoriesFormComponent,
        MaterialsComponent,
        MaterialsFormComponent,
        ItemsComponent,
        ItemsFormComponent,
        ItemsFormComponent,
        CalculationComponent,
        ConstructionComponent,
        ConstructionFormComponent,
        ConstructionDetailFormComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'families', component: FamiliesComponent },
            { path: 'families-add', component: FamiliesFormComponent },
            { path: 'families-edit/:id', component: FamiliesFormComponent },
            { path: 'categories', component: CategoriesComponent },
            { path: 'categories-add', component: CategoriesFormComponent },
            { path: 'categories-edit/:id', component: CategoriesFormComponent },
            { path: 'materials', component: MaterialsComponent },
            { path: 'materials-add', component: MaterialsFormComponent },
            { path: 'materials-edit/:id', component: MaterialsFormComponent },
            { path: 'items', component: ItemsComponent },
            { path: 'items-add', component: ItemsFormComponent },
            { path: 'items-edit/:id', component: ItemsFormComponent },
            { path: 'calculation/:id', component: CalculationComponent },
            { path: 'construction', component: ConstructionComponent },
            { path: 'construction-add', component: ConstructionFormComponent },
            { path: 'construction-edit/:id', component: ConstructionFormComponent },
            { path: 'construction-detail/:id', component: ConstructionDetailFormComponent },
        ]),
        BrowserAnimationsModule,
        NgxLoadingModule.forRoot({})
    ],
    providers: [DatePipe],
    bootstrap: [AppComponent]
})
export class AppModule { }
