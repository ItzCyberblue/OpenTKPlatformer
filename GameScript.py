# Importing libraries
import pygame
import settings
import player
import backgroundObject

pygameClock = pygame.time.Clock()
SetttingsObject = settings.Settings()
PlayerObject = player.Player()
ColorObject = settings.Color()


#Initilaizing Window
window = pygame.display.set_mode((SetttingsObject.ScreenWidth, SetttingsObject.ScreenHeight))
pygame.display.set_caption("Pygame Game")

# Set a background object
backgroundObjects = [backgroundObject.BackgroundObject()]
pygame.init()


joysticks = []
for i in range(0, pygame.joystick.get_count() - 1):
    joysticks.append(pygame.joystick.Joystick())





def MainLoop():
    while SetttingsObject.GameRunning == True and PlayerObject.Alive == True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                SetttingsObject.GameRunning = False
                # Added test comment


        PlayerObject.getInput(backgroundObjects)
        for backgroundObj in backgroundObjects:
            window.blit(pygame.image.load('cool.png'), (backgroundObj.PositionX, backgroundObj.PositionY))

        for spellObject in PlayerObject.SpellsEquipped:
            for bullet in spellObject.SpellObjects:
                bullet.MoveWithDirection()
                pygame.draw.rect(window, ColorObject.RED, pygame.Rect((bullet.PositionX, bullet.PositionY), (20, 50)))
        window.fill(ColorObject.BLACK)
        pygame.draw.rect(window, ColorObject.RED, pygame.Rect((PlayerObject.PositionX, PlayerObject.PositionY), (PlayerObject.Width, PlayerObject.Height)))
        

        pygame.display.flip()
        pygameClock.tick(60)




MainLoop()

