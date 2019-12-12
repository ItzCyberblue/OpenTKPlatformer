import pygame

class Player:
	PositionX = 375
	PositionY = 275
	Width = 50
	Height = 50
	directionFacing = "right"
	Alive = True

	def getInput(self, backgroundObjects):
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