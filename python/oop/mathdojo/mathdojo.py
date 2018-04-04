class MathDojo(object):
    def __init__(self):
        self.value = 0
    def add(self, *args):
        for i in range(0, len(args)):
            if type(args[i]) is list or type(args[i]) is tuple:
            #check if list or tuple
                for j in args[i]:
                    self.value += j
            else: 
                self.value += args[i]
        return self
    def subtract(self, *args):
        for i in range(0, len(args)):
            if type(args[i]) is list or type(args[i]) is tuple:
            #check if list or tuple
                for j in args[i]:
                    self.value -= j
            else: 
                self.value -= args[i]
        return self
    def result(self):
        print self.value
        return self

md = MathDojo()

md.add([1], 3, 4).add([3,5,7,8], [2,4.3,1.25]).subtract(2, [2,3], [1.1,2.3]).result()

