import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItiTracksComponent } from './iti-tracks.component';

describe('ItiTracksComponent', () => {
  let component: ItiTracksComponent;
  let fixture: ComponentFixture<ItiTracksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItiTracksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItiTracksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
