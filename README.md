
This is a basic example of how to make use of TickerQ. It is set up using EF for both TickerQ execution, and a example data backend to test interactions with other databases/job execution times.

Please ensure you have the necessary databases set up, and connection strings updated in the 'appsettings.development.json' file.

If you are running thing through VS, based on the launch settings chosen, the dashboard endpoint will be as follows:

http - http://localhost:5149/tickerq-dashboard <br>
https - https://localhost:7045/tickerq-dashboard

Findings:
1. When using 'CancelMissedTickersOnApplicationRestart' within the operational store, this doesn't seem to work as what I expected. Hence, this hasn't been used within the example. <br>
Expectation: If I restart my application, if the execution time of the job has been passed this should cancel the job.<br>
Reality: If I restart my application, all queued jobs get cancelled regardless of whether the execution time has elapsed.
