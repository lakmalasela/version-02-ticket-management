import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { EmployeeService } from '../../shared/services/employee/employee.service';
import { error } from 'console';
import { FormBuilder, FormGroup, NgForm, NgModel, Validators } from '@angular/forms';
import { EmployeeDetail } from '../../shared/services/employee/employee-detail.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { TicketHelper } from '../../_helpers/leaners-helperClass';
import { ComonService } from '../../shared/services/comon.service';

@Component({
    selector: 'app-form',
    templateUrl: './items.component.html',
    styleUrls: ['./items.component.scss','./item.css'],
    animations: [routerTransition()]
})
export class ItemsComponent implements OnInit {
    submitted = false;
      employeeData: any[];
      civilstatus: any[];
      designation: any[];
      branch:any[];
      employeeFields : string[] = ["Id","Itemname","Unitprice","itemType","Action"];
      itemListArray:any;
      displayedColumns: string[] = ["id", "Item Name", "Unit Price", "Issue Type","branch"];



      ItemTypeList =[{name:'Hardware',id:2},{name:'Software',id:1}]
      itemgroup:FormGroup;

      constructor(private router: Router,public commonService: ComonService,public service: EmployeeService,private toastr: ToastrService,private fb:FormBuilder) {}

      ngOnInit() {
       
        this.loadDefaultData()   
      }

 loadDefaultData(){
    this.itemgroup = this.fb.group({
        serialno :[TicketHelper.systemIdGenratr('T_')],
        Itemname :['',Validators.required],
        itemType:[1],
        Unitprice :['',Validators.required]
    })


    this.commonService.getInventory()
    .subscribe
    (res=>{
        this.itemListArray = res;
    })

 }

 get f(){
    return this.itemgroup.controls;
}
      //submit data
      onSubmit(){
        this.submitted = true;
        if(this.itemgroup.valid) {
            this.commonService.saveInventory(this.itemgroup.value)
            .subscribe(
                res=>{
                    console.log(res);
                    this.toastr.success('Inserted Successfully','Inventory Created')
                    console.log("Success Submit ",res);
                    this.loadDefaultData();
                }
            )
        }
      }



UpdateItem(){
    this.submitted = true;
            this.commonService.updateInventory(this.itemgroup.value)
            .subscribe(
                res=>{
                    console.log(res);
                    this.toastr.success('Updated Successfully','Inventory Updated')
                    console.log("Success Submit ",res);
                    this.loadDefaultData();
                }
            )
}



 



}
