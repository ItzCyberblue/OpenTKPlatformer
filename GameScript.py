import pygame
import settings
import player



SetttingsObject = settings.Settings()
PlayerObject = player.Player()
ColorObject = settings.Color()

window = pygame.display.set_mode((SetttingsObject.ScreenWidth, SetttingsObject.ScreenHeight))
pygame.display.set_caption("Pygame Game")





pygame.init()

def MainLoop():
    while SetttingsObject.GameRunning == True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                SetttingsObject.GameRunning = False


MainLoop()
