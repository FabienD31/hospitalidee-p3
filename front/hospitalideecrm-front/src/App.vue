<template>
  <div id="app">
    <div id="nav">
      <nav class="navbar navbar-expand-lg static-top">
        <div class="container-fluid">
          <a class="navbar-brand" href="/">
            <img
              class="img-responsive"
              src="../src/assets/hospitalidee_logo.png"
              style="width:15em; height:auto"
              alt="hospitalidee"
            />
          </a>
          <button
            class="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarResponsive"
            aria-controls="navbarResponsive"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="navbar" id="navbarResponsive">
            <ul class="navbar-nav">
              <li class="nav-item active">
                <a class="nav-link active" href="/"
                  >Inscription
                </a>
              </li>
              <li class="nav-item">
                <a class="nav-link" href="/list">Administration</a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>

    <router-view></router-view>
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

h2 {
  color: #16428a;
  text-align: center;
  margin: 1em;
  padding: 1em;
}

h3 {
  color: #42b983;
  font-size: 1, 2rem;
  margin: 0;
}

#nav a {
  font-weight: bold;
  color: #16428A;
}

</style>
