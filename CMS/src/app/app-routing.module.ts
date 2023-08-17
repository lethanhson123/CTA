import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { CategoryLanguageComponent } from './category-language/category-language.component';
import { ContactComponent } from './contact/contact.component';
import { AboutComponent } from './about/about.component';
import { BannerComponent } from './banner/banner.component';
import { CareerComponent } from './career/career.component';
import { IdeasComponent } from './ideas/ideas.component';
import { NewsComponent } from './news/news.component';
import { ProjectComponent } from './project/project.component';
import { ServiceComponent } from './service/service.component';
import { TeamComponent } from './team/team.component';

const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  {
    path: 'Homepage', component: AboutComponent,
  },   
  {
    path: 'CategoryLanguage', component: CategoryLanguageComponent,
  }, 
  {
    path: 'Contact', component: ContactComponent,
  }, 
  {
    path: 'About', component: AboutComponent,
  }, 
  {
    path: 'Banner', component: BannerComponent,
  }, 
  {
    path: 'Career', component: CareerComponent,
  }, 
  {
    path: 'Ideas', component: IdeasComponent,
  }, 
  {
    path: 'News', component: NewsComponent,
  }, 
  {
    path: 'Project', component: ProjectComponent,
  }, 
  {
    path: 'Service', component: ServiceComponent,
  }, 
  {
    path: 'Team', component: TeamComponent,
  }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
