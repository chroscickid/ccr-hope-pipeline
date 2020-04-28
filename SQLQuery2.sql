SELECT refform.clientCode, refform.fname, refform.lname, refform.dob, refform.guardianName, refform.guardianlName, refform.guardianRelationship,
refform.strAddress, refform.gender, refform.guardianEmail,
refform.guardianPhone, refform.meeting, refform.youthInDuvalSchool, refform.youthInSchool, refform.issues, 
refform.currentSchool, refform.zip, refform.grade, refform.currStatus, refform.arrest, refform.school, refform.dateInput, 
meetingDate, email, reach, moreInfo, reason, referralfname, referrallname, nameOrg, youthNu, youthEmail, youthCit, youthOffense, 
refform.youthImpact, refform.youthAlt, refform.youthSetting, refform.youthInjunction, attachments.filename
from refform
left join attachments on refform.clientCode = attachments.clientCode
WHERE dbo.refform.clientCode = '10fe74f4-884a-4bdc-b6cf-0a5ac4dc5aaa';
