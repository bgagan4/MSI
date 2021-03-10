import { Component, OnInit } from '@angular/core';
import {ISubjectAddress} from '../types';
import {ApiServiceService} from '../api-service.service';

@Component({
  selector: 'app-subject-address-page',
  templateUrl: './subject-address-page.component.html',
  styleUrls: ['./subject-address-page.component.css']
})
export class SubjectAddressPageComponent implements OnInit {
  Address:string ='';
  City:string='';
        State:string='';
        Zip:string='';
        FirstName:string='';
        LastName:string='';
        Mi:string='';
        Suffix:string='';

  subjectAddress! : ISubjectAddress;
  success : boolean = false;
  
  constructor(private apiService:ApiServiceService) { }

  ngOnInit(): void {
    
  }

  onSubmit(detailsFormValues: any):void{
    this.subjectAddress = {
      Address: {
        Address:detailsFormValues.Address,
        City:detailsFormValues.City,
        State:detailsFormValues.State,
        Zip:detailsFormValues.Zip
    },
    Subject : {
        FirstName:detailsFormValues.FirstName,
        LastName:detailsFormValues.LastName,
        Mi:detailsFormValues.Mi,
        Suffix:detailsFormValues.Suffix
    }
  }

  this.apiService.saveSubjectAddress(this.subjectAddress).subscribe(
    sa => {
      if(sa != null)
      {
        this.success = true;
        this.Address ='';
        this.City='';
        this.State='';
        this.Zip='';
        this.FirstName='';
        this.LastName='';
        this.Mi='';
        this.Suffix='';
      }
      console.log(sa);
    },
    err => {
      console.log(err);
    }
  );

  

  }

}
