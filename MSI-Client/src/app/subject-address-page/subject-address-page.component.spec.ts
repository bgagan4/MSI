import { ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { SubjectAddressPageComponent } from './subject-address-page.component';
import { HttpClientModule } from '@angular/common/http';

describe('SubjectAddressPageComponent', () => {
  let component: SubjectAddressPageComponent;
  let fixture: ComponentFixture<SubjectAddressPageComponent>;
  let btn: HTMLButtonElement;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubjectAddressPageComponent ],
      imports: [HttpClientModule]
    })
    .compileComponents();
    fixture = TestBed.createComponent(SubjectAddressPageComponent);
    component = fixture.componentInstance;
    btn = fixture.debugElement.query(By.css('.btn')).nativeElement;
    fixture.detectChanges();
  });

  // beforeEach(() => {
  //   fixture = TestBed.createComponent(SubjectAddressPageComponent);
  //   component = fixture.componentInstance;
  //   btn = fixture.debugElement.query(By.css('.btn')).nativeElement;
  //   fixture.detectChanges();
    
  // });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should disable submit button when the form is invalid -- Address field is empty', () => {
    component.Address = "";
    fixture.detectChanges();
    expect(btn.disabled).toBeTruthy();
  });

  it('should enable submit button is the form is valid', () => {
    component.Address = "some text";
    component.City="some text";
    component.State="some text";
    component.Zip="some text";
    component.FirstName="some text";
    component.LastName="some text";
    component.Mi="some text";
    component.Suffix="some text";
    fixture.detectChanges();
    console.log(btn.disabled);
    expect(btn.disabled).toBeFalsy();
  });

});
