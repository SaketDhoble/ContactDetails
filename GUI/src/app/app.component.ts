import { Component, OnInit } from '@angular/core';
import {ContactDetails,ResultMessageE} from './contactDetails';
import {ContactDetailsService} from './contactDetailsService';

interface Labels {
  contactInfoLabel?: string;
  contactInfoModalLabel?:string;
  isSaveUpdateBtnLabel?:string
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers : [ContactDetailsService]
})
export class AppComponent implements OnInit{

  constructor(private contactDetailsService : ContactDetailsService)
  {

  }
  title = 'ContactInfoMgmt';

  dashBoardView : boolean = true;
  panelScrollHeight = screen.height;
  itemPerPage: number = 20;
  showAll: boolean = false;
  contactDetails : ContactDetails = {};
  contactDetailsList : ContactDetails[] = [];
  isCallSentToApi : boolean = false;

  ngOnInit()
  {
    
    this.getLabelsForPage();
    if (this.panelScrollHeight > 350)
    this.panelScrollHeight -= 350;

  }

  labels: Labels;
  getLabelsForPage() {
    this.labels = {
      contactInfoLabel: 'Contact Management System',
      contactInfoModalLabel : 'Add Contact',
      isSaveUpdateBtnLabel : "Save",
    }
  }
  ViewContactDetails()
  {
    this.dashBoardView = false;
    this.GetList();
  }

  GetList()
  {

    this.contactDetailsList = [];
    let apiUrl = "";

    // this.empContactDtlsService.GetAllContactDetailsList(apiUrl).subscribe(
    //   list => {
    //     if (list != null && list != undefined && list.length > 0) {
    //       this.contactDetailsList  = list;
    //     }
    //   },
    //   err => {
      
    //   }
    // )

    
    let obj: ContactDetails = {
      IdContactDetails: 1,
      FirstName: "Saket",
      LastName: "Dhoble",
      PhoneNo : 9284115514,
      Email : "saket.dhoble@gmail.com",
      IsActive : 1,
    }

    this.contactDetailsList.push(obj);

    let obj1: ContactDetails = {
      IdContactDetails: 2,
      FirstName: "Prajakta",
      LastName: "Dhoble",
      PhoneNo : 9284115514,
      Email : "saket.dhoble@gmail.com",
      IsActive : 1,
    }

    this.contactDetailsList.push(obj1);

    let obj2: ContactDetails = {
      IdContactDetails: 3,
      FirstName: "Sonal",
      LastName: "Dhoble",
      PhoneNo : 9284115514,
      Email : "saket.dhoble@gmail.com",
      IsActive : 1,
    }

    this.contactDetailsList.push(obj2);

    
  }


  allowOnlyNumbers(event) {
    return event.charCode == 8 || event.charCode == 0
      ? null
      : event.charCode >= 48 && event.charCode <= 57;
  }
  ShowAllRecords()
  {
    
  }

  AddContactDtls()
  {
    this.labels.contactInfoModalLabel = "Add Contact";
    this.labels.isSaveUpdateBtnLabel = "Save";
  }
  SaveEmpDtls() {
  
    if(this.contactDetails.IdContactDetails > 0)
    {
        this.PostEditContactDtls(this.contactDetails);
    }
    else
    {
      this.PostInsertContactDtls();
    }
}

PostInsertContactDtls()
{

  if (this.isCallSentToApi) { }
  else
  {
    this.isCallSentToApi = true;
    
    this.contactDetails.CreatedBy = 1;
    this.contactDetails.CreatedOn = new Date();
    this.contactDetails.IsActive = 1;
   
    this.contactDetailsService.PostNewEmpDtls(this.contactDetails)
    .subscribe(result => {
      this.isCallSentToApi = false;
        if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {

          var x = document.getElementById("snackbar");
          x.innerHTML = "Contact details added successfully.";
          x.className = "show";
          x.style.background = "Black";
          setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);


        } else {
          var x = document.getElementById("snackbar");
          x.innerHTML = "Falied to save contact details.";
          x.className = "show";
          x.style.background = "Black";
          setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

        }
    },
        err => {
        });
    }

}


EditContactDtls(contactObj : ContactDetails)
{
  this.labels.contactInfoModalLabel = "Edit Contact Details";
  this.labels.isSaveUpdateBtnLabel = "Update";
  if(contactObj != null && contactObj != undefined)
  {
    this.contactDetails = contactObj;
  }
}

PostEditContactDtls(contactObj : ContactDetails)
{
  if(contactObj != null && contactObj != undefined)
  {
   
    this.contactDetails = contactObj;
    this.contactDetails.CreatedBy = 1;
    this.contactDetails.CreatedOn = new Date();
    this.contactDetails.IsActive = 1;

    if (this.isCallSentToApi) { }
    else
    {
      this.isCallSentToApi = true;
      
     
      this.contactDetailsService.PostUpdateEmpDtls(this.contactDetails)
      .subscribe(result => {
        this.isCallSentToApi = false;
          if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {

            var x = document.getElementById("snackbar");
            x.innerHTML = "contact details updated successfully";
            x.className = "show";
            x.style.background = "Black";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);


          } else {
            var x = document.getElementById("snackbar");
            x.innerHTML = "Failed to update contact details";
            x.className = "show";
            x.style.background = "Black";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

          }
      },
          err => {
          });
      }

  }
}

DeactivateContact(contactObj : ContactDetails)
{

  if(contactObj != null && contactObj != undefined)
  {
    if (this.isCallSentToApi) { }
    else
    {
      this.isCallSentToApi = true;
      
     
      this.contactDetailsService.DeacticateContactDtls(contactObj.IdContactDetails)
      .subscribe(result => {
        this.isCallSentToApi = false;
          if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {
  
            var x = document.getElementById("snackbar");
            x.innerHTML = "Contact deactivated successfully";
            x.className = "show";
            x.style.background = "Black";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
  
  
          } else {
            var x = document.getElementById("snackbar");
            x.innerHTML = "Failed to deactivate contact details";
            x.className = "show";
            x.style.background = "Black";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
  
          }
      },
          err => {
          });
      }
  
  }
  

 


}

}
