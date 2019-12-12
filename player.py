import pygame
import Spell
import vector2
class Player:
	PositionX = 375
	PositionY = 275
	Width = 50
	Height = 50
	directionFacing = "RIGHT"
	Alive = True

	Health = 100
	Defense = 5
	Stamina = 100
	MagicPower = 20
	Strength = 10

	Inventory = []
	Spells = []
	SpellsEquipped = [Spell.Spell("Development God Tier Spell", Spell.SpellDamageRange(99999999, 99999999), False, 1, "house.jpg")]


	def ShootSpell(self, Number):
		print("Shot " + self.SpellsEquipped[Number - 1].name)
		self.SpellsEquipped[Number - 1].SpellObjects.append(Spell.SpellBullet(self.directionFacing, self.PositionX + self.Width/2, self.PositionY + self.Height/2, 5))

	def getInput(self, backgroundObjects):
		self.SpellsEquipped[0].cooldownnumber += 1
		keys = pygame.key.get_pressed()
		if keys[pygame.K_a]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionX += 1
			for SpellEquipped in self.SpellsEquipped:
				for bullet in SpellEquipped.SpellObjects:
					bullet.PositionX += 1
		if keys[pygame.K_d]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionX -= 1
			for SpellEquipped in self.SpellsEquipped:
				for bullet in SpellEquipped.SpellObjects:
					bullet.PositionX -= 1
		if keys[pygame.K_w]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionY += 1
			for SpellEquipped in self.SpellsEquipped:
				for bullet in SpellEquipped.SpellObjects:
					bullet.PositionY += 1
		if keys[pygame.K_s]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionY -= 1
			for SpellEquipped in self.SpellsEquipped:
				for bullet in SpellEquipped.SpellObjects:
					bullet.PositionY -= 1

		if keys[pygame.K_h]:
			if self.SpellsEquipped[0].cooldownnumber >= self.SpellsEquipped[0].maxcooldown:
				self.ShootSpell(1)
				self.SpellsEquipped[0].cooldownnumber = 0
