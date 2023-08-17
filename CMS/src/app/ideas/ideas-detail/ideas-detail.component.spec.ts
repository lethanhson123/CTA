import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdeasDetailComponent } from './ideas-detail.component';

describe('IdeasDetailComponent', () => {
  let component: IdeasDetailComponent;
  let fixture: ComponentFixture<IdeasDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IdeasDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IdeasDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
