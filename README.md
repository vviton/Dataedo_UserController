# Code Review:
1.	Zastosowanie http post zamiast http delete
2.	Zastosowanie metod synchronicznych zamiast asynchronicznych
3.	Logika związana z Data-Access w kontrolerze – sugeruję przeniesienie jej do repozytorium np. UserRepository i użycie go w kontrolerze.
4.	Wartość w zmiennej user po zastosowaniu FirstOrDefault może mieć wartość null – brak obsługi tego przypadku
5.	Z racji tego, że wyszukiwanie odbywa się po kluczu głównym rozważyłbym wymianę metody FirstOrDefault na FindAsync()
