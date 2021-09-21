import { Component, OnInit } from '@angular/core';
import { ContactDetails, ResultMessageE } from './contactDetails';
import { ContactDetailsService } from './contactDetailsService';
declare var jQuery: any;

interface Labels {
  contactInfoLabel?: string;
  contactInfoModalLabel?: string;
  isSaveUpdateBtnLabel?: string
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ContactDetailsService]
})
export class AppComponent implements OnInit {

  constructor(private contactDetailsService: ContactDetailsService) {

  }
  title = 'ContactInfoMgmt';

  dashBoardView: boolean = true;
  panelScrollHeight = screen.height;
  itemPerPage: number = 8;
  showAll: boolean = false;
  contactDetails: ContactDetails = {};
  contactDetailsList: ContactDetails[] = [];
  isCallSentToApi: boolean = false;

  ngOnInit() {

    this.getLabelsForPage();
    if (this.panelScrollHeight > 350)
      this.panelScrollHeight -= 350;

  }

  labels: Labels;
  getLabelsForPage() {
    this.labels = {
      contactInfoLabel: 'Contact Management System',
      contactInfoModalLabel: 'Add Contact',
      isSaveUpdateBtnLabel: "Save",
    }
  }
  ViewContactDetails() {
    this.dashBoardView = false;
    this.GetAllContactList();
  }

  GetAllContactList() {

    this.contactDetailsList = [];

    this.contactDetailsService.GetAllContactDetailsList().subscribe(
      list => {
        if (list != null && list != undefined && list.length > 0) {
          this.contactDetailsList = list;
        }
      },
      err => {

      }
    )

  }


  allowOnlyNumbers(event) {
    return event.charCode == 8 || event.charCode == 0
      ? null
      : event.charCode >= 48 && event.charCode <= 57;
  }
  ShowAllRecords() {
    if (this.showAll) {
      this.itemPerPage = this.contactDetailsList.length;
    }
    else {
      this.itemPerPage = 8;
    }
  }

  AddContactDtls() {
    this.contactDetails = {};
    this.labels.contactInfoModalLabel = "Add Contact";
    this.labels.isSaveUpdateBtnLabel = "Save";
  }
  SaveEmpDtls() {

    if (this.contactDetails.IdContactDetails > 0) {
      this.PostEditContactDtls();
    }
    else {
      this.PostInsertContactDtls();
    }
  }

  PostInsertContactDtls() {

    if (this.isCallSentToApi) { }
    else {
      this.isCallSentToApi = true;

      this.contactDetails.CreatedBy = 1;
      this.contactDetails.CreatedOn = new Date();
      this.contactDetails.IsActive = 1;

      this.contactDetailsService.PostNewEmpDtls(this.contactDetails)
        .subscribe(result => {
          this.isCallSentToApi = false;
          if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {

            jQuery("#contactDtlsModal").modal("hide");
            this.GetAllContactList();
            var x = document.getElementById("snackbar");
            x.innerHTML = result.DisplayMessage;
            x.className = "show";
            x.style.background = "#5ab733";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);


          } else {
            var x = document.getElementById("snackbar");
            x.innerHTML = "Falied to save contact details.";
            x.className = "show";
            x.style.background = "#5ab733";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

          }
        },
          err => {
          });
    }

  }


  EditContactDtls(contactObj: ContactDetails) {
    this.labels.contactInfoModalLabel = "Edit Contact Details";
    this.labels.isSaveUpdateBtnLabel = "Update";
    if (contactObj != null && contactObj != undefined) {
      this.contactDetails = Object.assign({}, contactObj);
    }
  }

  PostEditContactDtls() {
    
      this.contactDetails.CreatedBy = 1;
      this.contactDetails.CreatedOn = new Date();
      this.contactDetails.IsActive = 1;

      if (this.isCallSentToApi) { }
      else {
        this.isCallSentToApi = true;


        this.contactDetailsService.PostUpdateEmpDtls(this.contactDetails)
          .subscribe(result => {
            this.isCallSentToApi = false;
            if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {

              jQuery("#contactDtlsModal").modal("hide");
              this.GetAllContactList();
              var x = document.getElementById("snackbar");
              x.innerHTML = result.DisplayMessage;
              x.className = "show";
              x.style.background = "#5ab733";
              setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);


            } else {
              var x = document.getElementById("snackbar");
              x.innerHTML = "Failed to update contact details";
              x.className = "show";
              x.style.background = "#5ab733";
              setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

            }
          },
            err => {
            });
      }

    
  }

  DeactivateContact(contactObj: ContactDetails) {
    if (contactObj != null && contactObj != undefined) {
      if (this.isCallSentToApi) { }
      else {
        this.isCallSentToApi = true;
        contactObj.IsActive = 0;

        this.contactDetailsService.DeacticateContactDtls(contactObj)
          .subscribe(result => {
            this.isCallSentToApi = false;
            if (result.Result == 1 || result.MessageType == ResultMessageE.Information) {

              jQuery("#contactDtlsModal").modal("hide");
              this.GetAllContactList();
              var x = document.getElementById("snackbar");
              x.innerHTML = "Contact deactivated successfully";
              x.className = "show";
              x.style.background = "#5ab733";
              setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);


            } else {
              var x = document.getElementById("snackbar");
              x.innerHTML = "Failed to deactivate contact details";
              x.className = "show";
              x.style.background = "#5ab733";
              setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);

            }
          },
            err => {
            });
      }

    }





  }

}
