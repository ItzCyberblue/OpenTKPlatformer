import pygame
import settings
import player



SettingsObject = settings.Settings()
PlayerObject = player.Player()
ColorObject = settings.Color()

window = pygame.display.set_mode((SettingsObject.ScreenWidth, SettingsObject.ScreenHeight))
pygame.display.set_caption("Platformer Made Out of Boredom")




pygame.init()

def MainLoop():
    while SettingsObject.GameRunning == True:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                SettingsObject.GameRunning = False



MainLoop()
