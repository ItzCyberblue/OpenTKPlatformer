import pygame

class Spell:
    def __init__(self, name, damageRange, usage, cooldown, image):
        self.name = name
        self.damageRange = damageRange
        self.usage = usage
        self.maxcooldown = cooldown * 60
        self.cooldownnumber = cooldown * 60
        self.image = image

        self.pygameTextureImage = pygame.image.load(image)
        self.SpellObjects = []

class SpellDamageRange:
    def __init__(self, min, max):
        self.max = max
        self.min = min


class SpellBullet:
    def __init__(self, directionFacingAtStart, PositionX, PositionY, Speed):
        self.directionFacingAtStart = directionFacingAtStart
        self.PositionX = PositionX
        self.PositionY = PositionY
        self.Speed = Speed

    def MoveWithDirection(self):
        if(self.directionFacingAtStart == "RIGHT"):
            self.PositionX += self.Speed
        if(self.directionFacingAtStart == "UP"):
            self.PositionY -= self.Speed
        if(self.directionFacingAtStart == "LEFT"):
            self.PositionX -= self.Speed
        if(self.directionFacingAtStart == "DOWN"):
            self.PositionY += self.Speed