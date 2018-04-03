class Bike(object):
    def __init__(self, price, max_speed, miles=0):
        self.price = price
        self.max_speed = max_speed
        self.miles = miles
    def displayinginfo(self):
        print "Price: {}, Max Speed: {}, Miles: {}".format(self.price, self.max_speed, self.miles)
        return self
    def riding(self):
        print "Riding"
        self.miles += 10
        return self
    def reversing(self):
        print "Reversing"
        self.miles -= 5
        if self.miles < 0:
            self.miles = 0
        return self


bike1 = Bike(200, "25mph")
bike2 = Bike(100, "20mph")
bike3 = Bike(50, "10mph")

print bike1.riding().riding().riding().reversing().displayinginfo()
print bike2.riding().riding().reversing().reversing().displayinginfo()
print bike3.reversing().reversing().reversing().displayinginfo()



