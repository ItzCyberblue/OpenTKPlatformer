import pygame
import Spell
import vector2
class Player:
	PositionX = 375
	PositionY = 275
	Width = 50
	Height = 50
	directionFacing = "right"
	Alive = True

	Health = 100
	Defense = 5
	Stamina = 100
	MagicPower = 20
	Strength = 10

	Inventory = []
	Spells = []
	SpellsEquipped = [Spell.Spell("Test Spell", Spell.SpellDamageRange(30, 90), False, 1)]


	def ShootSpell(self, Number):
		print("Shot " + self.SpellsEquipped[Number - 1].name)

	def getInput(self, backgroundObjects):
		self.SpellsEquipped[0].cooldownnumber += 1
		keys = pygame.key.get_pressed()
		if keys[pygame.K_a]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionX += 1
		if keys[pygame.K_d]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionX -= 1
		if keys[pygame.K_w]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionY += 1
		if keys[pygame.K_s]:
			for backgroundObject in backgroundObjects:
				backgroundObject.PositionY -= 1

		if keys[pygame.K_h]:
			if self.SpellsEquipped[0].cooldownnumber >= self.SpellsEquipped[0].maxcooldown:
				self.ShootSpell(1)
				self.SpellsEquipped[0].cooldownnumber = 0