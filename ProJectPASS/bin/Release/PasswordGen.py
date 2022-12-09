import sys
sys.path.append(r'C:\Python34\Lib')

import random

strokSymbEng = "abcdefghijklmnopqrstuvwxyz"
ZAGSymbEng = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
strokSymbRus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"
ZAGSymbRus = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"
SpecSIMB = "1234567890-=.><`~\/{}[]|?!''"

def Generator(Lenght, LangType):
    TempString = ""
    if (LangType == "Russian"):
        SelectedType = []
        SelectedType.append(ZAGSymbRus)
        SelectedType.append(strokSymbRus)
        SelectedType.append(SpecSIMB)
        for i in range(Lenght):
            elem = random.choice(SelectedType)
            TempString += random.choice(elem)
    elif (LangType == "English"):
        SelectedType = []
        SelectedType.append(ZAGSymbEng)
        SelectedType.append(strokSymbEng)
        SelectedType.append(SpecSIMB)
        for i in range(Lenght):
            elem = random.choice(SelectedType)
            TempString += random.choice(elem)
    elif (LangType == "Multipl"):
        SelectedType = []
        SelectedType.append(ZAGSymbRus)
        SelectedType.append(strokSymbRus)
        SelectedType.append(strokSymbEng)
        SelectedType.append(ZAGSymbEng)
        SelectedType.append(SpecSIMB)
        for i in range(Lenght):
            elem = random.choice(SelectedType)
            TempString += random.choice(elem)

    return TempString
