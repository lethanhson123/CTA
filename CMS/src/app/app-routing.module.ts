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
import { AboutInfoComponent } from './about/about-info/about-info.component';
import { CareerDetailComponent } from './career/career-detail/career-detail.component';
import { BannerDetailComponent } from './banner/banner-detail/banner-detail.component';
import { IdeasDetailComponent } from './ideas/ideas-detail/ideas-detail.component';
import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { ProjectDetailComponent } from './project/project-detail/project-detail.component';
import { ServiceDetailComponent } from './service/service-detail/service-detail.component';
import { TeamDetailComponent } from './team/team-detail/team-detail.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { CategoryIdeasComponent } from './category-ideas/category-ideas.component';
import { NewsletterComponent } from './newsletter/newsletter.component';
import { CandidateComponent } from './candidate/candidate.component';
import { MembershipComponent } from './membership/membership.component';
import { AwardComponent } from './award/award.component';
import { AwardInfoComponent } from './award/award-info/award-info.component';
import { EmailComponent } from './email/email.component';
import { MenuComponent } from './menu/menu.component';
import { QuoteComponent } from './quote/quote.component';
import { SocialNetworkComponent } from './social-network/social-network.component';

const routes: Routes = [  
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  {
    path: 'Homepage', component: AboutComponent,
  },   
  {
    path: 'Email', component: EmailComponent,
  }, 
  {
    path: 'Menu', component: MenuComponent,
  }, 
  {
    path: 'Quote', component: QuoteComponent,
  }, 
  {
    path: 'SocialNetwork', component: SocialNetworkComponent,
  },   
  {
    path: 'CategoryLanguage', component: CategoryLanguageComponent,
  }, 
  {
    path: 'Contact', component: ContactComponent,
  }, 
  {
    path: 'Feedback', component: FeedbackComponent,
  }, 
  {
    path: 'CategoryIdeas', component: CategoryIdeasComponent,
  }, 
  {
    path: 'Membership', component: MembershipComponent,
  }, 
  {
    path: 'Newsletter', component: NewsletterComponent,
  }, 
  {
    path: 'Candidate', component: CandidateComponent,
  }, 
  {
    path: 'About', component: AboutComponent,
  }, 
  {
    path: 'About', children: [
      {
        path: 'List', component: AboutComponent,
      },     
      {
        path: 'Info/:ID', component: AboutInfoComponent,
      },
    ]
  },
  {
    path: 'Award', component: AwardComponent,
  }, 
  {
    path: 'Award', children: [
      {
        path: 'List', component: AwardComponent,
      },     
      {
        path: 'Info/:ID', component: AwardInfoComponent,
      },
    ]
  },
  {
    path: 'Banner', component: BannerComponent,
  }, 
  {
    path: 'Banner', children: [
      {
        path: 'List', component: CareerComponent,
      },     
      {
        path: 'Info/:ID', component: BannerDetailComponent,
      },
    ]
  },
  {
    path: 'Career', component: CareerComponent,
  }, 
  {
    path: 'Career', children: [
      {
        path: 'List', component: CareerComponent,
      },     
      {
        path: 'Info/:ID', component: CareerDetailComponent,
      },
    ]
  },
  {
    path: 'Ideas', component: IdeasComponent,
  }, 
  {
    path: 'Ideas', children: [
      {
        path: 'List', component: IdeasComponent,
      },     
      {
        path: 'Info/:ID', component: IdeasDetailComponent,
      },
    ]
  },
  {
    path: 'News', component: NewsComponent,
  }, 
  {
    path: 'News', children: [
      {
        path: 'List', component: NewsComponent,
      },     
      {
        path: 'Info/:ID', component: NewsDetailComponent,
      },
    ]
  },
  {
    path: 'Project', component: ProjectComponent,
  }, 
  {
    path: 'Project', children: [
      {
        path: 'List', component: ProjectComponent,
      },     
      {
        path: 'Info/:ID', component: ProjectDetailComponent,
      },
    ]
  },
  {
    path: 'Service', component: ServiceComponent,
  }, 
  {
    path: 'Service', children: [
      {
        path: 'List', component: ServiceComponent,
      },     
      {
        path: 'Info/:ID', component: ServiceDetailComponent,
      },
    ]
  },
  {
    path: 'Team', component: TeamComponent,
  }, 
  {
    path: 'Team', children: [
      {
        path: 'List', component: TeamComponent,
      },     
      {
        path: 'Info/:ID', component: TeamDetailComponent,
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, initialNavigation: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
