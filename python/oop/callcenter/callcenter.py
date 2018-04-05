class Call(object):
    def __init__(self, name, number, time, reason):
        import uuid
        self.id = str(uuid.uuid4())
        self.name = name
        self.number = number 
        self.time = time 
        self.reason = reason
    def display(self):
        print "Id:", self.id
        print "Name:", self.name
        print "Number:", self.number
        print "Time:", self.time 
        print "Reason:", self.reason
        return self

class CallCenter(object):
    def __init__(self):
        self.calls = []
        self.queue = len(self.calls)
    def add(self, *call):
        for i in range(0, len(call)):
            self.calls.append(call[i])
            self.queue += 1
        return self
    def remove(self):
        self.calls.pop(0)
        self.queue -= 1
        return self
    def removeCall(self, number):
        for i in self.calls:
            if i.number == number:
                self.calls.remove(i)
                self.queue -= 1
        return self
    def info(self):
        for i in range(0, len(self.calls)):
            print self.calls[i].name, self.calls[i].number
        print "Calls in Queue:", self.queue
        return self

call1 = Call('John', '312-000-0000', '4:54pm', 'Callback')
call2 = Call('Jane', '312-111-1111', '4:55pm', "Check Balance")
call3 = Call('Joe', '312-222-2222', '5:05pm', 'Wire Transfer')

center1 = CallCenter().add(call1, call2, call3).remove().removeCall('312-111-1111').info()
            


