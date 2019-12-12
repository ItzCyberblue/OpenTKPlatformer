import pygame

class Spell:
    def __init__(self, name, damageRange, usage, cooldown):
        self.name = name
        self.damageRange = damageRange
        self.usage = usage
        self.maxcooldown = cooldown * 60
        self.cooldownnumber = cooldown * 60

class SpellDamageRange:
    def __init__(self, min, max):
        self.max = max
        self.min = min