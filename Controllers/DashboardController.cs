using armcoordination_dashboard.Data;
using armcoordination_dashboard.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public IActionResult dashboardCurrent(int id)
        {
            List<int> right_arm = new List<int>();
            List<int> left_arm = new List<int>();

            if (_dashboardRepository.numberOfSession(id) > 0)
            {
                session _session = _dashboardRepository.lastSession(id);
                right_arm.Add(_session.hits_right_arm);
                right_arm.Add(_session.failures_right_arm);

                left_arm.Add(_session.hits_left_arm);
                left_arm.Add(_session.failures_left_arm);

                ViewBag.maximum_response = _session.maximum_response;
                ViewBag.minimum_response = _session.minimum_response;
                ViewBag.average_response = Math.Round(_session.average_response, 2);

                ViewBag.right_arm = right_arm;
                ViewBag.left_arm = left_arm;
                ViewBag.accuracy = Math.Round((_session.accuracy_percentage * 100), 2);
                ViewBag.not_accuracy = Math.Round((100 - (_session.accuracy_percentage * 100)), 2);
            }
            else
            {
                right_arm.Add(0);
                right_arm.Add(0);

                left_arm.Add(0);
                left_arm.Add(0);

                ViewBag.maximum_response = 0;
                ViewBag.minimum_response = 0;
                ViewBag.average_response = 0;

                ViewBag.right_arm = right_arm;
                ViewBag.left_arm = left_arm;
                ViewBag.accuracy = 0.0;
                ViewBag.not_accuracy = 0.0;
            }

            ViewBag.idChild = id;

            return View();
        }


        public IActionResult dashboardHistory(int id)
        {
            int numberOfSession = _dashboardRepository.numberOfSession(id);
            int counter_numberOfSession = numberOfSession;

            List<int> tittles = new List<int>();

            List<double> accuracy_percentage_values = new List<double>();
            List<double> average_response_values = new List<double>();

            List<int> hits_left_arm_values = new List<int>();
            List<int> hits_right_arm_values = new List<int>();

            List<int> failures_left_arm_values = new List<int>();
            List<int> failures_right_arm_values = new List<int>();

            if (numberOfSession > 0)
            {
                List<session> sessions = _dashboardRepository.getSessions(id);

                if (numberOfSession >= 12)
                {
                    counter_numberOfSession = numberOfSession;
                    foreach (session _sesion in sessions)
                    {
                        accuracy_percentage_values.Add(Math.Round(_sesion.accuracy_percentage*100, 2));
                        average_response_values.Add(Math.Round(_sesion.average_response, 2));
                        hits_left_arm_values.Add(_sesion.hits_left_arm);
                        hits_right_arm_values.Add(_sesion.hits_right_arm);
                        failures_left_arm_values.Add(_sesion.failures_left_arm);
                        failures_right_arm_values.Add(_sesion.failures_right_arm);

                        tittles.Add(counter_numberOfSession);
                        counter_numberOfSession--;
                    }
                }
                else
                {
                    counter_numberOfSession = numberOfSession;
                    for (int i = 0; i < 12; i++)
                    {
                        if (i+1 <= numberOfSession)
                        {
                            accuracy_percentage_values.Add(Math.Round(sessions[i].accuracy_percentage*100, 2));
                            average_response_values.Add(Math.Round(sessions[i].average_response, 2));
                            hits_left_arm_values.Add(sessions[i].hits_left_arm);
                            hits_right_arm_values.Add(sessions[i].hits_right_arm);
                            failures_left_arm_values.Add(sessions[i].failures_left_arm);
                            failures_right_arm_values.Add(sessions[i].failures_right_arm);

                            tittles.Add(counter_numberOfSession);
                            counter_numberOfSession--;
                        }
                        else
                        {
                            accuracy_percentage_values.Add(0f);
                            average_response_values.Add(0f);
                            hits_left_arm_values.Add(0);
                            hits_right_arm_values.Add(0);
                            failures_left_arm_values.Add(0);
                            failures_right_arm_values.Add(0);

                            tittles.Add(0);
                        }
                    }
                }

                hits_left_arm_values.Reverse();
                hits_right_arm_values.Reverse();
                average_response_values.Reverse();
                accuracy_percentage_values.Reverse();
                failures_left_arm_values.Reverse();
                failures_right_arm_values.Reverse();

                tittles.Reverse();

                ViewBag.hits_right_arm_values = hits_right_arm_values;
                ViewBag.hits_left_arm_values = hits_left_arm_values;
                ViewBag.average_response_values = average_response_values;
                ViewBag.accuracy_percentage_values = accuracy_percentage_values;
                ViewBag.failures_left_arm_values = failures_left_arm_values;
                ViewBag.failures_right_arm_values = failures_right_arm_values;

                ViewBag.tittles = tittles;
                

            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    accuracy_percentage_values.Add(0f);
                    average_response_values.Add(0f);
                    hits_left_arm_values.Add(0);
                    hits_right_arm_values.Add(0);
                    failures_left_arm_values.Add(0);
                    failures_right_arm_values.Add(0);

                    tittles.Add(0);
                }


                ViewBag.hits_right_arm_values = hits_right_arm_values;
                ViewBag.hits_left_arm_values = hits_left_arm_values;
                ViewBag.average_response_values = average_response_values;
                ViewBag.accuracy_percentage_values = accuracy_percentage_values;
                ViewBag.failures_left_arm_values = failures_left_arm_values;
                ViewBag.failures_right_arm_values = failures_right_arm_values;

                ViewBag.tittles = tittles;
            }

            ViewBag.idChild = id;
            return View();
        }

    }
}
