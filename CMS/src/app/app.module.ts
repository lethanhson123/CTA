import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { CKEditorModule } from 'ngx-ckeditor';
import { NotificationService } from './shared/Notification.service';
import { CookieService } from 'ngx-cookie-service';
import { ChartsModule } from 'ng2-charts';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { AppComponent } from './app.component';
import { LoadingComponent } from './loading/loading.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CategoryLanguageComponent } from './category-language/category-language.component';
import { ContactComponent } from './contact/contact.component';
import { ContactDetailComponent } from './contact/contact-detail/contact-detail.component';
import { CareerComponent } from './career/career.component';
import { CareerDetailComponent } from './career/career-detail/career-detail.component';
import { IdeasComponent } from './ideas/ideas.component';
import { IdeasDetailComponent } from './ideas/ideas-detail/ideas-detail.component';
import { NewsComponent } from './news/news.component';
import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { ProjectComponent } from './project/project.component';
import { ProjectDetailComponent } from './project/project-detail/project-detail.component';
import { ServiceComponent } from './service/service.component';
import { ServiceDetailComponent } from './service/service-detail/service-detail.component';
import { TeamComponent } from './team/team.component';
import { TeamDetailComponent } from './team/team-detail/team-detail.component';
import { BannerComponent } from './banner/banner.component';
import { BannerDetailComponent } from './banner/banner-detail/banner-detail.component';
import { AboutComponent } from './about/about.component';
import { AboutDetailComponent } from './about/about-detail/about-detail.component';
import { AboutInfoComponent } from './about/about-info/about-info.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { NewsletterComponent } from './newsletter/newsletter.component';
import { CandidateComponent } from './candidate/candidate.component';
import { CategoryIdeasComponent } from './category-ideas/category-ideas.component';
import { MembershipComponent } from './membership/membership.component';
import { AwardComponent } from './award/award.component';
import { AwardInfoComponent } from './award/award-info/award-info.component';
import { EmailComponent } from './email/email.component';
import { MenuComponent } from './menu/menu.component';
import { QuoteComponent } from './quote/quote.component';
import { SocialNetworkComponent } from './social-network/social-network.component';
import { MenuDetailComponent } from './menu/menu-detail/menu-detail.component';




@NgModule({
  declarations: [
    AppComponent,
    LoadingComponent,
    HomepageComponent,
    CategoryLanguageComponent,
    ContactComponent,
    ContactDetailComponent,
    CareerComponent,
    CareerDetailComponent, 
    IdeasComponent,    
    IdeasDetailComponent, 
    NewsComponent, 
    NewsDetailComponent, 
    ProjectComponent, 
    ProjectDetailComponent, 
    ServiceComponent, 
    ServiceDetailComponent, 
    TeamComponent, 
    TeamDetailComponent,   
    BannerComponent, 
    BannerDetailComponent, 
    AboutComponent, 
    AboutDetailComponent, AboutInfoComponent, FeedbackComponent, NewsletterComponent, CandidateComponent, CategoryIdeasComponent, MembershipComponent, AwardComponent, AwardInfoComponent, EmailComponent, MenuComponent, QuoteComponent, SocialNetworkComponent, MenuDetailComponent, 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ChartsModule,
    CKEditorModule,
  ],
  providers: [   
    CookieService,  
    NotificationService,
    {provide: MAT_DATE_LOCALE, useValue: 'en-GB'}
  ],
  bootstrap: [AppComponent],
  entryComponents:[]
})
export class AppModule { }
