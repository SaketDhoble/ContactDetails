import { Injectable } from '@angular/core'
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import {ContactDetails,ResultMessage} from './contactDetails'
import myGlobalVal = require('./global');

@Injectable()
export class ContactDetailsService {
    constructor(private http: Http) {

    }
   
    GetAllContactDetailsList(): Observable<ContactDetails[]> {
        return this.http.get(myGlobalVal.GetAllContactDetails)
            // ...and calling .json() on the response to return data
            .map((res: Response) => res.json())
            //...errors if any
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    PostNewEmpDtls(contactDetails: ContactDetails): Observable<ResultMessage> {
        // var params = {
        //     contactDetails: contactDetails,
        // };
        // let bodyString = JSON.stringify(params);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(myGlobalVal.PostSaveContactDetailsTO, contactDetails, options)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    PostUpdateEmpDtls(contactDetails: ContactDetails): Observable<ResultMessage> {
        // var params = {
        //     contactDetails: contactDetails,
        // };
        // let bodyString = JSON.stringify(params);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(myGlobalVal.PostUpdateContactDetailsTO, contactDetails, options)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }

    DeacticateContactDtls(contactDetailsId: number): Observable<ResultMessage> {
        // var params = {
        //     contactDetailsId: contactDetailsId,
        // };
        // let bodyString = JSON.stringify(params);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.put(myGlobalVal.UpdateContactDetailsTO, contactDetailsId, options)
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
    }
 
}