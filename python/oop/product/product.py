class Product(object):
    def __init__(self, price, item_name, weight, brand, status="for sale"):
        self.price = price
        self.item_name = item_name
        self.weight = weight
        self.brand = brand
        self.status = status
    def sell(self):
       self.status = "sold"
       return self
    def tax(self, amount):
       self.price += amount
       return self
    def return_product(self, reason):
        if reason == "defective":
            self.status = "defective"
            self.price = 0
            return self
        elif reason == "like new":
            self.status = "for sale"
            return self
        elif reason == "opened":
            self.status = "used"
            self.price *= 0.8
            return self
    def display_info(self):
        print "Price: {}".format(self.price)
        print "Item Name: {}".format(self.item_name)
        print "Weight: {}".format(self.weight)+"g"
        print "Brand: {}".format(self.brand)
        print "Status: {}".format(self.status)
        return self

product1 = Product(100, "Zen Pad", 10, "Dojo")

print product1.tax(1.65).sell().return_product('opened').display_info()

