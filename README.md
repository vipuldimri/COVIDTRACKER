# COVIDTRACKER
API's

https://localhost:44309/User 
{
    "name":"A",
    "PhoneNo":"1111111111",
    "pinCode":"111111"
}



https://localhost:44309/User/SelfAssessment
{
    "userId":1,
    "symptoms":["fever"],
    "travelHistory":true,
    "contactWithCovidPatient":true
}

https://localhost:44309/Admin/RegisterAdmin
{
    "name":"B",
    "PhoneNo":"1111111112",
    "pinCode":"111111"
}


https://localhost:44309/Admin/updateCovidResult
{ 
     "userId":1,
     "adminId":2,
     "result":"positive"
}
