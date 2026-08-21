/*
 Navicat Premium Data Transfer

 Source Server         : MySQL
 Source Server Type    : MySQL
 Source Server Version : 80013
 Source Host           : localhost:3306
 Source Schema         : lab

 Target Server Type    : MySQL
 Target Server Version : 80013
 File Encoding         : 65001

 Date: 18/06/2023 18:23:42
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dati
-- ----------------------------
DROP TABLE IF EXISTS `dati`;
CREATE TABLE `dati`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `timu` varchar(10000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dati
-- ----------------------------
INSERT INTO `dati` VALUES (1, '﻿1:实验室制取氧气时，装药品的大试管口应（ ） :A、 朝下 :B、朝上 :C、略向下倾斜 :D、略向上倾斜 :3\r\n2:实验室采用排水法收集氧气时，需将导气管伸入盛满水的集气瓶，这个操作应在（ ） :A、加热固体药品前 :B、与加热固体药品同时  :C、开始有气泡放出时 :D、气泡连续并均匀放出时 :4\r\n3:实验中，试管加入棉花团主要是为了（ ） :A、 防止药品反应时堵住导管 :B、降低实验温度 :C、标记试管口位置 :D、吸收水蒸气 :1\r\n4:装入药品最好的方式（ ） :A、用药瓶直接倒入试管 :B、用药匙直接倒入 :C、用药匙盛好药品深入试管底部后导入 :D、用手抓取药品放入试管:3 \r\n5:哪个是酒精灯正确的操作（ ） :A、用嘴吹灭点燃的酒精灯 :B、酒精灯盖子盖灭酒精灯火焰 :C、用点燃的酒精灯点燃另一盏酒精灯 :D、倒转酒精灯 :2\r\n6:高锰酸钾制氧气的化学实验属于什么反应（ ） :A、 酸碱中和反应 :B、合成反应 :C、分解反应 :D、置换反应:3\r\n7:检验气密性正确的步骤（ ） :A、装好试管塞-导管深入水中-热毛巾或手握住试管 :B、热毛巾或手握住试管-装好试管塞-导管深入水中 :C、装好试管塞-热毛巾或手握住试管-导管深入水中 :D、导管深入水中-热毛巾或手握住试管-装好试管塞 :1\r\n8:向上排空气法导管应放在（ ） :A、集气瓶瓶口 :B、集气瓶内中间处 :C、集气瓶瓶口一定高度 :D、集气瓶内部底部 :4 \r\n9:铁架台夹子应夹在试管什么位置（ ） :A、 离试管口1/3处 :B、离试管口2/3处 :C、离试管口 :D、试管底部 :1 \r\n10:实验结束时候应立即作什么操作（ ） :A、先移走导管再熄灭酒精灯 :B、先熄灭酒精灯后移走导管 :C、从铁架台上取下试管 :D、均无影响 :1\r\n11:加热158克高锰酸钾可以制取氧气多少克（ ） :A、79克 :B、18克 :C、16克 :D、32克 :3');
INSERT INTO `dati` VALUES (2, NULL);

-- ----------------------------
-- Table structure for students
-- ----------------------------
DROP TABLE IF EXISTS `students`;
CREATE TABLE `students`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `number` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `password` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `score` int(5) NULL DEFAULT NULL,
  `syscore` int(5) NULL DEFAULT NULL,
  `syscorepq` int(5) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of students
-- ----------------------------
-- Student records intentionally omitted. Create local test users after import.

SET FOREIGN_KEY_CHECKS = 1;
