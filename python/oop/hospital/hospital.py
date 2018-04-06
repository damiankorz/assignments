class Patient(object):
    num_patients = 0 
    def __init__(self, name, allergies, bed_num='None'):
        self.name = name 
        self.allergies = allergies
        self.bed_num = bed_num
        self.id = Patient.num_patients
        Patient.num_patients += 1

class Hospital(object):
    def __init__(self, name, capacity):
        self.patients = []
        self.name = name 
        self.capacity = capacity
        self.beds = self.assign_bed()
    def assign_bed(self):
        beds = []
        for i in range(0, self.capacity):
            beds.append({
                "bed_id": i,
                "Available": True
            })
        return beds
    def admit(self, patient):
        if len(self.patients) < self.capacity:
        #less than since zero is taken into account
            self.patients.append(patient)
            for i in range(0, len(self.beds)):
                if self.beds[i]["Available"]:
                    patient.bed_num = self.beds[i]["bed_id"]
                    self.beds[i]["Available"] = False
                    print "Successfuly Admitted {}".format(patient.name)
                    break
        else: 
            print "Hospital at Capacity"
        return self
    def discharge(self, patient_id):
        for patient in self.patients:
            if patient.id == patient_id:
                for bed in self.beds:
                    if bed["bed_id"] == patient.bed_num:
                        bed["Available"] = True
                        break
                self.patients.remove(patient)
                print "Discharged {}".format(patient.name)  
        return self






