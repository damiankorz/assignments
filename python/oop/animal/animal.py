class Animal(object):
    def __init__(self, name, health):
        self.name = name
        self.health = health
    def walk(self):
        self.health -= 1
        if self.health < 0:
            self.health = 0
        return self
    def run(self):
        self.health -= 5
        if self.health <0:
            self.health = 0
        return self
    def displayHealth(self):
        print "Name: {}".format(self.name)
        print "Health: {}".format(self.health)
        return self

class Dog(Animal):
    def __init__(self, name, health=150):
        super(Dog, self).__init__(name, health)
    def pet(self):
        self.health += 5
        return self

class Dragon(Animal):
    def __init__(self, name, health=170):
        super(Dragon, self).__init__(name, health)
    def fly(self):
        self.health -= 10
        return self
    def displayHealth(self):
        super(Dragon, self).displayHealth()
        print "This is a dragon!"
        return self


animal1 = Animal('Donkey Kong', 100)

print animal1.walk().walk().walk().run().run().displayHealth()

dog1 = Dog("Santa's Little Helper")

print dog1.walk().walk().walk().run().run().pet().displayHealth()

dragon1 = Dragon("Smaug")

print dragon1.fly().displayHealth()





