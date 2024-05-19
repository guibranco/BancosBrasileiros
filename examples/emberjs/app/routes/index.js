import Route from '@ember/routing/route';
import bancos from 'bancos-brasileiros';

export default class IndexRoute extends Route {
  async model() {
    return bancos;
  }
}
