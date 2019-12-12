import pygame
import settings
import player

import backgroundObject


SetttingsObject = settings.Settings()
ColorObject = settings.Color()
window = pygame.display.set_mode((SetttingsObject.ScreenWidth, SetttingsObject.ScreenHeight))
pygame.display.set_caption("Pygame Game")

backgroundObjects = [backgroundObject.BackgroundObject()]
pygame.init()


joysticks = []
for i in range(0, pygame.joystick.get_count() - 1):
    joysticks.append(pygame.joystick.Joystick())




pygame.init()

def MainLoop():
    while SetttingsObject.GameRunning == True:
    while SetttingsObject.GameRunning == True and PlayerObject.Alive == True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                SetttingsObject.GameRunning = False
                # Added test comment
        PlayerObject.getInput(backgroundObjects)

        window.fill(ColorObject.BLACK)
        pygame.draw.rect(window, ColorObject.RED, pygame.Rect((PlayerObject.PositionX, PlayerObject.PositionY), (PlayerObject.Width, PlayerObject.Height)))
        for backgroundObj in backgroundObjects:
            pygame.draw.rect(window, (255, 255, 255), pygame.Rect((backgroundObj.PositionX, backgroundObj.PositionY), (30, 40)))

        pygame.display.flip()




MainLoop()
