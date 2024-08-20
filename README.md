# Code Test: Lookup Service - Level 3

> I have uploaded this test for hiring managers to get an idea of my skill level. This readme has been abbreviated and anonymized in order to not spoil the test for anyone who might come across it in the wild. The Cypress tests were provided for me, the rest is all my own code. I spent a few hours on the test in total.

## Requirements

Your task is to build a backend service that implements the [Lookup Service REST API](https://infra.devskills.app/lookup/api/1.0.0) and integrates with the [Credit Data REST API](https://infra.devskills.app/credit-data/api/1.0.0) to aggregate historical credit data.

- Do your best to make the [provided E2E tests](cypress/e2e/test.cy.js) pass.
- Implement DB caching controlled by `Cache-Control` headers, provided both in the requests to your service, as well as received in the responses from Credit Data API. 
    - We can limit ourselves here only to `no-store` and `max-age` directives. Please make yourself familiar with their semantics using the following links: 
        * `no-store` [request](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control#no-store_2) and [response](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control#no-store) directives
        * `max-age` [request](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control#max-age_2) and [response](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control#max-age) directives
    - These `control-cache` headers will be returned only by `/personal-details` endpoint
- Be mindful about error handling. The API tests are not restricting any particular service behaviour so it is up to you to choose a solution that feels right.
- Avoid duplication and extract re-usable modules where it makes sense. We want to see your approach to creating a codebase that is easy to maintain.
- Unit test one module of choice. There is no need to test the whole app, as we only want to understand what you take into consideration when writing unit tests.

## Getting the tests to run

Complete the steps below to make the E2E tests run correctly:
1. Update the `baseUrl` (where your frontend runs) in [cypress.config.js](cypress.config.js).
2. Update the [`build`](package.json#L5) and [`start`](package.json#L6) scripts in [package.json](package.json) to respectively build and start your app.

<details>
  <summary>Running the E2E tests</summary>

  > ⚠️ Before executing the tests, ensure [Node](https://nodejs.org/en) is installed and your app is running.

  ```bash
  npm install
  npm run test
  ```

</details>
