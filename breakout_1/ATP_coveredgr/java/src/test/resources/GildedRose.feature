Feature: Gilded Rose conjured item
  I want to know the quality is updated properly

  Scenario: Backstage pass after the show
    Given The item as "Backstage passes to a TAFKAL80ETC concert"
    And The item has Sellin of 0
    And the item has Quality of 20
    When I update the shop inventory
    Then I should get item with SellIn of -1
    And I should get item with Quality of 0

  Scenario: Conjured item before SellIn date
    Given The item as "Conjured Mana Bun"
    And The item has Sellin of 10
    And the item has Quality of 5
    When I update the shop inventory
    Then I should get item with Quality of 3

  Scenario: Conjured item after SellIn date
    Given The item as "Conjured Mana Bun"
    And The item has Sellin of 0
    And the item has Quality of 10
    When I update the shop inventory
    Then I should get item with Quality of 6


#  Scenario: Conjured item after SellIn date
#    Given The item as "Conjured Mana Bun"
#    And The item is before Sellin
#    And the item has Quality is positive
#    When I update the shop inventory
#    Then I should get item with Quality reduced twice as fast as regular item
#
#
