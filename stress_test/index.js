import http from 'k6/http';
import { sleep } from 'k6';

//10 vus usuarios
//x duration segundos de duração

export const options = {
    vus: 2000,
    duration: '30s',
};

export default function() {
    http.get('http://localhost:8080/');
    sleep(1);
}